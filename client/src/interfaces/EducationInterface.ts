export default interface EducationInterface {
  playerSchoolId: number;
  schoolId: number;

  // Joined School Details
  schoolName: string;
  logoUrl?: string | null;
  city?: string | null;
  state?: string | null;

  // Academic Details
  startYear: number;
  endYear?: number | null;
  startMonth: number;
  endMonth?: number | null;
  level?: string | null;
  gpa?: number | null;
  sat?: number | null;
  act?: number | null;
  isCurrent: boolean;
}
