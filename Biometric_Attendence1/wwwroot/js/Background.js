//// Define light shades of RGB colors
//const colors = ['#bdc3c7', '#7f8c8d', '#3498db', '#2ecc71']; // Adjust these colors as needed

//let index = 0;

//function changeColor() {
//    document.body.style.background = `linear-gradient(to right, ${colors[index]}, ${colors[(index + 1) % colors.length]})`;

//    index = (index + 1) % colors.length;
//}

//// Change color every 3 seconds
//setInterval(changeColor, 3000);
//const colors = ['#bdffbf', '#ffebef', '#ccb0ff']; // Adjust these colors as needed
const colors = ['#fbf7f4', '#ede4ff', '#ddcaff', '#cdb1ff'];
let index = 0;
let steps = 50; // Number of steps for the transition
let currentStep = 0;

function changeColor() {
    const color1 = colors[index];
    const color2 = colors[(index + 1) % colors.length];

    const stepR = (parseInt(color2.slice(1, 3), 16) - parseInt(color1.slice(1, 3), 16)) / steps;
    const stepG = (parseInt(color2.slice(3, 5), 16) - parseInt(color1.slice(3, 5), 16)) / steps;
    const stepB = (parseInt(color2.slice(5, 7), 16) - parseInt(color1.slice(5, 7), 16)) / steps;

    const newColor = `rgb(${parseInt(color1.slice(1, 3), 16) + stepR * currentStep}, 
                         ${parseInt(color1.slice(3, 5), 16) + stepG * currentStep}, 
                         ${parseInt(color1.slice(5, 7), 16) + stepB * currentStep})`;

    document.body.style.background = `linear-gradient(to right, ${color1}, ${newColor})`;
   document.querySelector('.navbar').style.background = newColor;

    currentStep++;
    if (currentStep > steps) {
        currentStep = 0;
        index = (index + 1) % colors.length;
    }
    setTimeout(changeColor, 100); // Adjust the timeout for smoother transition
}

changeColor();
