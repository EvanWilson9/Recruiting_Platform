export default interface AthleticCareerInterface {
  athleticCareersId: number;
  playerId: number;
  schoolName: string;
  sport: string;
  level: string;
  startYear: number;
  endYear?: number | null;
  startMonth: number;
  endMonth?: number | null;
}
