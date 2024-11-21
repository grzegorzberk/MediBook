import React, { useState, useEffect } from "react";
import { motion } from "framer-motion";
import { FaStethoscope } from "react-icons/fa";
import "./AnimatedPage.css";

const AnimatedPage = ({ children }) => {
  const [isTransitioning, setIsTransitioning] = useState(false);

  const pageVariants = {
    initial: {
      opacity: 0,
      scale: 0.95,
    },
    in: {
      opacity: 1,
      scale: 1,
    },
    out: {
      opacity: 0,
      scale: 0.95,
    },
  };

  const pageTransition = {
    type: "spring",
    stiffness: 60,
    damping: 20,
    duration: 0.1,
  };

  useEffect(() => {
    setIsTransitioning(true);
    const timer = setTimeout(() => setIsTransitioning(false), 500);
    return () => clearTimeout(timer);
  }, []);

  return (
    <motion.div
      initial="initial"
      animate="in"
      exit="out"
      variants={pageVariants}
      transition={pageTransition}
      className="page-container"
    >
      {isTransitioning && (
        <div className="loading-overlay">
          <FaStethoscope className="loading-icon" />
        </div>
      )}
      {children}
    </motion.div>
  );
};

export default AnimatedPage;