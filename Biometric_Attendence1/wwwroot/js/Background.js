// Define an array of related colors (shades of yellow and green)
const colors = ['#FFFF00', '#FAFF00', '#E6FF00', '#CCFF00', '#B3FF00', '#99FF00', '#80FF00', '#66FF00', '#4DFF00', '#33FF00', '#1AFF00', '#00FF00'];

// Initialize index
let index = 0;

// Function to change background color
function changeColor() {
    // Update body background color
    document.body.style.background = `linear-gradient(45deg, ${colors[index]}, ${colors[(index + 1) % colors.length]})`;

    // Update navbar background color
    document.querySelector('.navbar').style.background = `linear-gradient(45deg, ${colors[index]}, ${colors[(index + 1) % colors.length]})`;

    // Increment index (with wrap-around)
    index = (index + 1) % colors.length;
}

// Call changeColor function every 2 seconds
setInterval(changeColor, 2000);
