let accessToken: string | null = null;

export function getAccessToken(){
    return accessToken;
}

export function setAccessToken(newToken: string | null){
    accessToken = newToken;
}