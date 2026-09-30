import { getAccessToken, setAccessToken } from "../context/tokenStore";

const API_URL = import.meta.env.VITE_API_URL;
let refreshPromise: Promise<boolean> | null = null;

async function refreshAccessToken(): Promise<boolean> {
    if (!refreshPromise) {
        refreshPromise = (async () => {
            try {
                const res = await fetch(`${API_URL}/api/refresh`, {
                    method: "POST",
                    credentials: "include",
                });

                if (!res.ok) {
                    setAccessToken(null);
                    return false;
                }

                const data = await res.json();
                setAccessToken(data.accessToken);
                return true;
            } catch {
                setAccessToken(null);
                return false;
            } finally {
                refreshPromise = null;
            }
        })();
    }
    return refreshPromise;
}

export async function apiFetch(
    endpoint: string,
    options: RequestInit = {},
    retry = true
): Promise<Response> {
    const token = getAccessToken();

    const response = await fetch(`${API_URL}${endpoint}`, {
        ...options,
        credentials: "include",
        headers: {
            "Content-Type": "application/json",
            ...(token && { Authorization: `Bearer ${token}` }),
            ...options.headers,
        },
    });

    if (response.status === 401 && retry) {
        const refreshed = await refreshAccessToken();
        if (refreshed) {
            return apiFetch(endpoint, options, false);
        }
    }

    return response;
}