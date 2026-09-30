interface AthleticCareerInterface {
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

interface AthleticCareerProps {
  athleticCareer: AthleticCareerInterface[];
}

const AthleticCareer = ({ athleticCareer }: AthleticCareerProps) => {
  return (
    <section>
      <h2>Athetic Career</h2>
      <div>
        {athleticCareer.map((ac: AthleticCareerInterface) => {
          return (
            <div key={ac.athleticCareersId}>
              {ac.playerId}
              <br />
              {ac.schoolName}
              <br />
              {ac.sport}
              <br />
              {ac.level}
              <br />
              <div>
                {ac.startYear} {ac.startMonth}
              </div>
              <div>
                {ac.endYear}
                {ac.endMonth}
              </div>
            </div>
          );
        })}
      </div>
    </section>
  );
};

export default AthleticCareer;
