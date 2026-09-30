import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";

const LoginPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState<string | null>(null);
  const { login } = useAuth();
  const navigate = useNavigate();

  
  async function handleLogin(e: any) {
    e.preventDefault();   
    setError(null); 
    
    if(email == "" || password == ""){
      setError("Both email and password are required.");
      return;
    } 

    try{
      await login(email, password); 
      navigate("/my-profile");

    } catch (error){
      console.error(error);
      setError("Invalid email or password");
    } finally {
      setPassword("");
    }
  }

  return (
    <div>
      <h1>Log In</h1>
      <form onSubmit={handleLogin} className="login-form">
        <div>
          <label>Email</label>
          <input 
            type="email" 
            value={email} 
            onChange={(e) => setEmail(e.target.value)} />
        </div>
        <div>
          <label>Password</label>
          <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <div>
          <button type="submit">Submit</button>
        </div>
        <div>Don't have an account? <Link to={"/create-account"}>Create Account</Link></div>
      </form>
      {error && <div style={{ color:'red' }}>{error}</div>}
    </div>
  );
};

export default LoginPage;
