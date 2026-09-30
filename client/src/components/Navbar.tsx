import { useState } from "react";
import { Link, useLocation } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import {
  Home,
  Users,
  UserCircle,
  LogOut,
  LogIn,
  UserPlus,
  Briefcase,
  Menu,
  X,
} from "lucide-react";

const Navbar = () => {
  const { isLoggedIn, logout } = useAuth();
  const [menuOpen, setMenuOpen] = useState(false);
  const location = useLocation();

  const closeMenu = () => setMenuOpen(false);

  // Helper to determine if a route is active
  const isActive = (path: string) => location.pathname === path;

  return (
    <header className="navbar-wrapper">
      <div className="navbar-container">
        {/* Brand/Logo Area */}
        <Link className="navbar-brand" to="/" onClick={closeMenu}>
          <div className="brand-icon">RP</div>
          <h1 className="navbar-title">Recruiting Platform</h1>
        </Link>

        {/* Mobile Toggle Button */}
        <button
          className="navbar-toggle"
          onClick={() => setMenuOpen(!menuOpen)}
          aria-label="Toggle navigation"
          aria-expanded={menuOpen}
        >
          {menuOpen ? <X size={24} /> : <Menu size={24} />}
        </button>

        {/* Navigation Items */}
        <nav className={`navbar-links ${menuOpen ? "navbar-links-open" : ""}`}>
          <Link
            to="/"
            onClick={closeMenu}
            className={`nav-item ${isActive("/") ? "nav-item-active" : ""}`}
          >
            <Home size={20} className="nav-icon" />
            <span className="nav-label">Home</span>
          </Link>

          <Link
            to="/players"
            onClick={closeMenu}
            className={`nav-item ${isActive("/players") ? "nav-item-active" : ""}`}
          >
            <Users size={20} className="nav-icon" />
            <span className="nav-label">Players</span>
          </Link>

          {isLoggedIn ? (
            <>
              <Link
                to="/my-profile"
                onClick={closeMenu}
                className={`nav-item ${isActive("/my-profile") ? "nav-item-active" : ""}`}
              >
                <UserCircle size={20} className="nav-icon" />
                <span className="nav-label">My Profile</span>
              </Link>

              <Link
                to="/"
                onClick={() => {
                  logout();
                  closeMenu();
                }}
                className="nav-item nav-item-logout"
              >
                <LogOut size={20} className="nav-icon" />
                <span className="nav-label">Logout</span>
              </Link>

              <div className="navbar-status">
                <span className="status-dot"></span>
                Logged In
              </div>
            </>
          ) : (
            <>
              <Link
                to="/login"
                onClick={closeMenu}
                className={`nav-item ${isActive("/login") ? "nav-item-active" : ""}`}
              >
                <LogIn size={20} className="nav-icon" />
                <span className="nav-label">Login</span>
              </Link>

              <Link
                to="/create-account"
                onClick={closeMenu}
                className={`nav-item ${isActive("/create-account") ? "nav-item-active" : ""} nav-item-accent`}
              >
                <UserPlus size={20} className="nav-icon" />
                <span className="nav-label">Join Now</span>
              </Link>
            </>
          )}
        </nav>
      </div>
    </header>
  );
};

export default Navbar;
