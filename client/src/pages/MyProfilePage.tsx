import { useEffect, useState } from "react";
import Header from "../components/myprofile-components/Header";
import { apiFetch } from "../api/apiClient";
import { useAuth } from "../context/AuthContext";
import type UserProfile from "../interfaces/UserProfile";
import type AthleticCareerInterface from "../interfaces/AthleticCareerInterface";
import type EducationInterface from "../interfaces/EducationInterface";
import About from "../components/myprofile-components/About";
import PhysicalStats from "../components/myprofile-components/PhysicalStats";
import AthleticCareer from "../components/myprofile-components/AthleticCareer";
import Education from "../components/myprofile-components/Education";

const MyProfilePage = () => {
  const [isLoading, setIsLoading] = useState(true);
  const [user, setUser] = useState<UserProfile | null>(null);
  const [athleticCareer, setAthleticCareer] = useState<
    AthleticCareerInterface[]
  >([]);
  const [education, setEducation] = useState<EducationInterface[]>([]);
  const auth = useAuth();

  useEffect(() => {
    retrieveProfileData();
  }, []);

  async function retrieveProfileData() {
    try {
      // Auth not working fr...
      console.log(auth.user?.id + " Test");

      // Hard coded api call
      // Need to change auth to OAuth (janky auth rn)
      const response = await apiFetch(`/api/profile/8`);
      const athleticCareerRes = await apiFetch("/api/profile/career/1");
      const educationRes = await apiFetch("/api/profile/education/1");

      if (!response.ok) {
        throw new Error("Error was thrown");
      }

      const json = await response.json();
      const athleticCareerData = await athleticCareerRes.json();
      const educationData = await educationRes.json();

      setUser(json);
      setAthleticCareer(athleticCareerData);
      setEducation(educationData);
    } catch (error) {
      console.error(error);
    } finally {
      setIsLoading(false);
    }
  }

  if (isLoading) return <div>Loading...</div>;

  {
    /*
     <section>Recruiting Timeline</section>
     <section>Highlight Film</section>
     <section>Photo Gallery</section>
     <section>Awards</section>
     <section>Contact</section> 
  */
  }

  return (
    <main className="myprofile-content">
      <div className="myprofile-wrapper">
        <Header
          firstname={user?.firstName}
          lastname={user?.lastName}
          city={user?.city}
          state={user?.state}
          country={user?.country}
          headline={user?.headline}
          height={user?.height}
          weight={user?.weight}
          profileImage={user?.profileImage}
          bannerImageUrl={user?.bannerImage}
        />

        <About aboutText={user?.about} />

        <PhysicalStats
          benchPress={user?.benchPress}
          backSquat={user?.backSquat}
          powerClean={user?.powerClean}
          verticalJump={user?.verticalJump}
          broadJump={user?.broadJump}
          fortyYardDash={user?.fortyYardDash}
        />

        <AthleticCareer athleticCareer={athleticCareer} />

        <Education education={education} />
      </div>
    </main>
  );
};

export default MyProfilePage;
