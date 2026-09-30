import { useEffect, useState } from "react";
// import { Link } from "react-router-dom"
import type User from "../interfaces/User.ts";
import { apiFetch } from "../api/apiClient.ts";

const LandingPage = () => {
  // const [users, setUsers] = useState<User[]>([]);
  // const [isLoading, setIsLoading] = useState(true);

  // const [name, setName] = useState('');
  // const [email, setEmail] = useState('');
  // const [password, setPassword] = useState('');

  // async function getData(){
  //     try{
  //         const response = await apiFetch(`/api/user`);

  //         if(!response.ok){
  //             throw new Error("Failed to fetch data.");
  //         }

  //         const json = await response.json();
  //         setUsers(json);
  //     } finally {
  //         setIsLoading(false);
  //     }
  // }

  // useEffect(()=> {
  //     getData();
  // },[])

  //   async function handleDeleteUser(id: number){
  //     try{
  //         const response = await apiFetch(`/api/user/${id}`, {
  //             method: 'DELETE'
  //         });

  //       if (!response.ok) {
  //         throw new Error('Network response failed');
  //       }

  //     await getData();

  //     } catch (error) {
  //       console.error(error);

  //     }
  //   }

  // if(isLoading) return <div>Loading...</div>

  return (
    <div>
      <h1>Landing Page</h1>
    </div>
  );
};

export default LandingPage;
