import {
  createContext,
  useContext,
  useState,
  useEffect,
  useCallback,
} from "react";
import { setAccessToken as setStoredAccessToken } from "./tokenStore";

interface User {
  id: number;
  email: string;
  name: string;
}

interface AuthContextType {
  token: string | null;
  user: User | null;
  isLoggedIn: boolean;
  isLoading: boolean;
  login: (email: string, password: string) => Promise<void>;
  logout: () => Promise<void>;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

const API_URL = import.meta.env.VITE_API_URL;
const API_BASE = `${API_URL}/api/auth`;

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [token, setToken] = useState<string | null>(null);
  const [user, setUser] = useState<User | null>(null);
  const [isLoading, setIsLoading] = useState(true);

  const isLoggedIn = token !== null;

  function applyAuthResult(data: {
    accessToken: string;
    userId: number;
    email: string;
    name: string;
  }) {
    setToken(data.accessToken);
    setStoredAccessToken(data.accessToken); // keep tokenStore in sync for apiFetch
    setUser({ id: data.userId, email: data.email, name: data.name });
  }

  function clearAuth() {
    setToken(null);
    setStoredAccessToken(null);
    setUser(null);
  }

  // On app load, try to silently refresh using the httpOnly cookie
  const tryRefresh = useCallback(async () => {
    try {
      const res = await fetch(`${API_BASE}/refresh`, {
        method: "POST",
        credentials: "include", // sends the httpOnly refresh cookie
      });

      if (!res.ok) {
        clearAuth();
        return;
      }

      const data = await res.json();
      applyAuthResult(data);
    } catch {
      clearAuth();
    } finally {
      setIsLoading(false);
    }
  }, []);

  useEffect(() => {
    tryRefresh();
  }, [tryRefresh]);

  async function login(email: string, password: string) {
    const res = await fetch(`${API_BASE}/login`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      credentials: "include", // lets server set the refresh cookie
      body: JSON.stringify({ email, password }),
    });

    if (!res.ok) {
      throw new Error("Login failed");
    }

    const data = await res.json();
    setToken(data.accessToken);
    setUser(data.user);
  }

  async function logout() {
    try {
      await fetch(`${API_BASE}/logout`, {
        method: "POST",
        credentials: "include",
      });
    } finally {
      setToken(null);
      setUser(null);
    }
  }

  return (
    <AuthContext.Provider
      value={{ token, user, isLoggedIn, isLoading, login, logout }}
    >
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  const context = useContext(AuthContext);

  if (!context) {
    throw new Error("useAuth must be used inside AuthProvider");
  }

  return context;
}
