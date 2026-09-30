interface AboutInterface {
  aboutText?: string | null;
}

const About = ({ aboutText }: AboutInterface) => {
  return (
    <section>
      <h2>About</h2>
      <div>{aboutText}</div>
    </section>
  );
};

export default About;
