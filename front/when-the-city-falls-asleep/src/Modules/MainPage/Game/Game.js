import React, { useState, useEffect, useRef } from "react";
import "./Game.css";

const Game = () => {
    const [score, setScore] = useState(0);
    const [isRunning, setIsRunning] = useState(false);
    const [copSpawn, setCopSpawn] = useState(null);
    const [mafiaSpawn, setMafiaSpawn] = useState(null);

    const gameRef = useRef(null);
    const startButtonRef = useRef(null);
    const crosshairRef = useRef(null);
    const scoreElementRef = useRef(null);
    const healthbarRef = useRef(null);

    const [health, setHealth] = useState(100);

        useEffect(() => {
            if (health <= 1) {
                gameOver();
            }
        }, [health]);

    function addPolice() {
        var game = gameRef.current;
        if (!game) {
            return;
        }
        if (game.querySelectorAll(".cop").length >= 8) {
            return;
        }

        var newCop = document.createElement("img");
        newCop.src = "Img/Game/cop.png";
        newCop.className = 'cop';

        newCop.onload = function () {
            var x = Math.random() * (game.offsetWidth - newCop.width);
            var y = Math.random() * (game.offsetHeight - newCop.height);
            newCop.style.position = "absolute";
            newCop.style.left = x + "px";
            newCop.style.top = y + "px";
            newCop.setAttribute("draggable", false);
            game.appendChild(newCop);
        };

        newCop.addEventListener("click", function () {
            setScore((score) => score + 1);
            this.style.opacity = '0';
            this.remove();
        });
    }

    function addMafia() {
        var game = gameRef.current;
        if (!game) {
            return;
        }
        if (game.querySelectorAll(".mafia").length >= 4) {
            return;
        }

        var newMafia = document.createElement("img");
        newMafia.src = "Img/Game/boss.png";
        newMafia.className = 'mafia';

        newMafia.onload = function () {
            var x = Math.random() * (game.offsetWidth - newMafia.width);
            var y = Math.random() * (game.offsetHeight - newMafia.height);
            newMafia.style.position = "absolute";
            newMafia.style.left = x + "px";
            newMafia.style.top = y + "px";
            newMafia.setAttribute("draggable", false);
            game.appendChild(newMafia);
        };

        newMafia.addEventListener("click", function () {
            setHealth((health) => health - 33.33333);
            this.remove();
        });
    }

    function startGame() {
        var game = gameRef.current;
        var startButton = startButtonRef.current;
        var crosshair = crosshairRef.current;
        var scoreElement = scoreElementRef.current;
        var healthbar = healthbarRef.current;
        setIsRunning(true);
        game.style.cursor = "none";
        startButton.style.display = "none";
        crosshair.style.top = "0";
        crosshair.style.left = "0";
        crosshair.style.display = "block";
        scoreElement.style.display = "block";
        scoreElement.className = '';
        healthbar.style.display = "block";
        addPolice();
        addPolice();
        addPolice();
        setCopSpawn(setInterval(addPolice, 1000));
        setMafiaSpawn(setInterval(addMafia, 2000));
        setHealth(100);
        setScore(0);
    }

    function gameOver() {
        var game = gameRef.current;
        var startButton = startButtonRef.current;
        var crosshair = crosshairRef.current;
        var scoreElement = scoreElementRef.current;
        var healthbar = healthbarRef.current;
        setIsRunning(false);
        game.style.cursor = "default";
        startButton.style.display = "block";
        crosshair.style.display = "none";
        // scoreElement.style.display = "none";
        scoreElement.className = 'final';
        healthbar.style.display = "none";
        clearInterval(copSpawn);
        clearInterval(mafiaSpawn);
        removeDudes();
    }

    function removeDudes() {
        const mafiaImages = document.querySelectorAll('.mafia');
        mafiaImages.forEach(image => image.remove());
        const copImages = document.querySelectorAll('.cop');
        copImages.forEach(image => image.remove());
    }

    useEffect(() => {
        const handleMouseMove = (event) => {
            var game = gameRef.current;
            var crosshair = crosshairRef.current;
            const containerRect = game.getBoundingClientRect();
            const x = event.clientX - containerRect.left - crosshair.clientWidth / 2;
            const y = event.clientY - containerRect.top - crosshair.clientHeight / 2;
            crosshair.style.transform = `translate(${x}px, ${y}px)`;
        };

        var game = gameRef.current;
        game.addEventListener("mousemove", handleMouseMove);

        return () => {
            game.removeEventListener("mousemove", handleMouseMove);
        };
    }, []);



    return (
        <div id="game" ref={gameRef}>
            <button id="start" ref={startButtonRef} onClick={startGame}>
                Пролить кровь
            </button>
            <img
                id="crosshair"
                ref={crosshairRef}
                src="Img/Game/Gunsight.svg"
                width="125"
                height="125"
            />
            <span id="score" ref={scoreElementRef}>
                Счет: {score}
            </span>
            <div id="healthbar" ref={healthbarRef}>
                <div id="health" style={{ width: health + "%" }}></div>
            </div>
        </div>
    );
};

export default Game;
