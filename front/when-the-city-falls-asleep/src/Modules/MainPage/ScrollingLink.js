import React, { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom';

const ScrollingLink = ({ to, children }) => {
  const textRef = useRef(null);
  const [scrollOffset, setScrollOffset] = useState(0);

  useEffect(() => {
    const handleScroll = () => {
      setScrollOffset(window.scrollY / 8);
    };

    window.addEventListener('scroll', handleScroll);

    return () => {
      window.removeEventListener('scroll', handleScroll);
    };
  }, []);

  const getOffset = (index) => {
    if (index % 2 === 0) {
      return scrollOffset;
    } else {
      return -scrollOffset;
    }
  };

  return (
    <Link to={to} className="our-families" ref={textRef}>
      {React.Children.map(children, (child, index) => (
        <span
          key={index}
          style={{
            transform: `translateX(${getOffset(index)}px)`,
          }}
        >
          {child}
        </span>
      ))}
      <img src="../Img/OurFamilies.png" />
    </Link>
  );
};

export default ScrollingLink;