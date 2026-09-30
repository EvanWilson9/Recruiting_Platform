import type EducationInterface from "../../interfaces/EducationInterface";

interface EducationProps {
  education: EducationInterface[];
}

const Education = ({ education }: EducationProps) => {
  return (
    <section>
      <h2>Education</h2>
      <div>
        {education.map((e: EducationInterface) => {
          return (
            <>
              <div key={e.playerSchoolId}>
                {e.schoolName}
                <br />
                {e.gpa}
                {e.isCurrent ? <div>Current</div> : <div>!Current</div>}
                {e.level}
                <div>
                  {e.startYear} {e.startMonth}
                </div>
                <div>
                  {e.endYear}
                  {e.endMonth}
                </div>
              </div>
              <br />
            </>
          );
        })}
      </div>
    </section>
  );
};

export default Education;
