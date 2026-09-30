import pfpImage from "../../assets/me-njtl picture.webp";
import bannerImage from "../../assets/ace.jpg";

interface HeaderDetails {
  firstname?: string | null;
  lastname?: string | null;
  city?: string | null;
  state?: string | null;
  country?: string | null;
  headline?: string | null;
  height?: number | null;
  weight?: number | null;
  profileImage?: string | null;
  bannerImageUrl?: string | null;
}

function formatHeight(totalInches?: number | null): string {
  if (!totalInches) return "N/A";
  const feet = Math.floor(totalInches / 12);
  const inches = Math.round(totalInches % 12);
  return `${feet}'${inches}"`;
}

export default function Header({
  firstname,
  lastname,
  city,
  state,
  country,
  headline,
  height,
  weight,
  profileImage,
  bannerImageUrl,
}: HeaderDetails) {
  const locationText = [city, state, country].filter(Boolean).join(", ");

  return (
    <section className="profile-header">
      <div className="banner">
        <img src={bannerImage} alt="" />
      </div>
      <div className="profile-content">
        <div className="profile-picture">
          <img src={pfpImage} alt="" />
        </div>
        <div className="profile-main">
          <div className="profile-left">
            <h1>
              {firstname ?? "First"} {lastname ?? "Last"}
            </h1>

            <p className="headline">{headline || "No headline added yet."}</p>

            {locationText && <div className="details">{locationText}</div>}

            <p className="details">
              <strong>HT:</strong> {formatHeight(height)} &nbsp;|&nbsp;{" "}
              <strong>WT:</strong> {weight ? `${weight} lbs` : "N/A"}
            </p>

            <div className="buttons">
              <div className="left-buttons">
                <button>Highlight Film</button>
                <button>Follow</button>
                <button>Contact</button>
              </div>

              <div>
                <button>Edit Profile</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
}
