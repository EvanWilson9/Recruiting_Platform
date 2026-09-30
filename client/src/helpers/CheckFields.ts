interface Fields{
    name?: string,
    email: string,
    password: string
}

export function checkFields({name, email, password}: Fields): string{
    if(!name){
        return "Name is required."
    }
    if(!email){
        return "Email is required."
    }
    if(!password){
        return "Password is required."
    }

    return "";
}