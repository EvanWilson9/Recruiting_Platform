import { useState } from "react";
import { Link } from "react-router-dom";
import { apiFetch } from "../../api/apiClient";
import { checkFields } from "../../helpers/CheckFields";

const CreateAccountPage = () => {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [error, setError] = useState<string | null>(null);
  const [password, setPassword] = useState("");

  async function handleCreateAccount(e: any) {
    
    e.preventDefault();

    const validationError: string = checkFields({name, email, password});

    if(validationError !== ""){
      setError(validationError);
      return;
    } 
  
    try{

      const payload = { name, email, password };

      const response = await apiFetch("/api/user", {
        method: "POST",
        body: JSON.stringify(payload),
      })
      
      if (!response.ok) {
        throw new Error('Network response failed');
      }

    } catch (error: any) {
      throw new Error("Error Message: ", error);

    } finally {
        setName('');
        setEmail('');
        setPassword('');
    }
  }

  return (
    <div>
      <h1>Create Account</h1>
      <form onSubmit={handleCreateAccount} className="login-form">
        <div>
          <label>Full Name</label>
          <input value={name} onChange={(e) => setName(e.target.value)} />
        </div>
        <div>
          <label>Email</label>
          <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
        </div>
        <div>
          <label>Password</label>
          <input type="password" value={password} onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <div>
          <button type="submit">Submit</button>
        </div>
        <div>Already have an account? <Link to={"/login"}>Log In</Link></div>
      </form>
      {error && <div style={{ color:"red" }}>{error}</div>}
    </div>
  );
};

export default CreateAccountPage;
