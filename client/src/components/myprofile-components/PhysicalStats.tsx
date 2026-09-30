interface PhysicalStatsInterface {
  benchPress?: number | null;
  backSquat?: number | null;
  powerClean?: number | null;
  verticalJump?: number | null;
  broadJump?: number | null;
  fortyYardDash?: number | null;
}

const PhysicalStats = ({
  benchPress,
  backSquat,
  powerClean,
  verticalJump,
  broadJump,
  fortyYardDash,
}: PhysicalStatsInterface) => {
  return (
    <section>
      <h2>Physical Stats</h2>
      <div>
        <p>Bench Press: {benchPress}</p>
        <p>Back Squat: {backSquat}</p>
        <p>Power Clean: {powerClean}</p>
        <p>Vertical Jump: {verticalJump}</p>
        <p>Broad Jump: {broadJump}</p>
        <p>40-yard Dash {fortyYardDash}</p>
      </div>
    </section>
  );
};

export default PhysicalStats;
