export default interface UserProfile {
  id: number;
  name: string;
  phone: string;
  zipcode: string;
  country: string;
  state: string;
  city: string;

  userId: number;
  firstName: string;
  lastName: string;
  email: string;
  role: string;

  playerId: number;
  headline?: string | null;
  about?: string | null;
  primaryPosition?: string | null;
  secondaryPosition?: string | null;
  classYear?: number | null;
  height?: number | null;
  weight?: number | null;

  benchPress?: number | null;
  backSquat?: number | null;
  powerClean?: number | null;
  verticalJump?: number | null;
  broadJump?: number | null;
  fortyYardDash?: number | null;

  profileImage?: string | null;
  bannerImage?: string | null;
}
