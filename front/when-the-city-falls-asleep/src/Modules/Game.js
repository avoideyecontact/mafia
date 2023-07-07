import React, { useState, useEffect, useRef } from 'react';
import "./Game.css"

const Game = () => {

    const [score, setScore] = useState(0);
    const [isRunning, setIsRunning] = useState(false);

    function addPolice() {
        var game = gameRef.current;
        if (game.querySelectorAll('img').length >= 9)
        {
            return;
        }

        var newCop = document.createElement("img");
        newCop.src = "Img/Game/cop.png";
        
        newCop.onload = function() {
            var x = Math.random() * (game.offsetWidth - newCop.width);
            var y = Math.random() * (game.offsetHeight - newCop.height);
            newCop.style.position = "absolute";
            newCop.style.left = x + "px";
            newCop.style.top = y + "px";
            newCop.setAttribute('draggable', false);
            game.appendChild(newCop);
        }

        newCop.addEventListener("click", function() {
            setScore(score => score + 1);
            this.remove();
        });
        
    }

    function startGame() {
        var game = gameRef.current;
        var startButton = startButtonRef.current;
        var crosshair = crosshairRef.current;
        setIsRunning(true);
        game.style.cursor = "none";
        startButton.style.display = "none";
        crosshair.style.top = "0";
        crosshair.style.left = "0";
        crosshair.style.display = "block";
        addPolice();
        addPolice();
        addPolice();
        setInterval(addPolice, 1000);
    }

    useEffect(() => {

        const handleMouseMove = (event) => {

        }
    
        document.addEventListener('mousemove', handleMouseMove);
    
        return () => {
          document.removeEventListener('mousemove', handleMouseMove);
        };
      }, []);

    const gameRef = useRef(null);
    const startButtonRef = useRef(null);
    const crosshairRef = useRef(null);

    return (

        <div id="game" ref={gameRef}>
            <button id="start" ref={startButtonRef} onClick={startGame}>Пролить кровь</button>
            <img id="crosshair" ref={crosshairRef} src="Img/Game/Gunsight.svg" width="125" height="125"/>
            <span id="score">Счет: {score}</span>
        </div>

  );
};

export default Game;