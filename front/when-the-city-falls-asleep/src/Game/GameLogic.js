
const game = document.getElementById("game");
const startButton = document.getElementById("start")
const crosshair = document.getElementById("crosshair");
const scoreElement = document.getElementById("score");
var isRunning = false;
var score = 0;

startButton.addEventListener("click", function() {
    startGame();
});

function moveCrosshair(event) {
    if (isRunning) {
        const containerRect = document.getElementById("game").getBoundingClientRect();
        const x = event.clientX - containerRect.left - (crosshair.clientWidth / 2);
        const y = event.clientY - containerRect.top - (crosshair.clientHeight / 2);
        crosshair.style.transform = `translate(${x}px, ${y}px)`;
    }
}

function updateScore() {
    score++;
    scoreElement.textContent = "Счет: " + score;
}

function addPolice() {
    if (game.querySelectorAll('img').length >= 9)
    {
        return;
    }

    var newCop = document.createElement("img");
    newCop.src = "cop.png";
    
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
        updateScore();
        this.remove();
    });
    
}

function startGame() {
    isRunning = true;
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

document.getElementById("game").addEventListener("mousemove", moveCrosshair);
