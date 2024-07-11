// Create an array with "James" and "Brennie"
let styles = ["James", "Brennie"];
console.log(styles); 

// Append "Robert" to the end
styles.push("Robert");
console.log(styles); 

// Replace the middle value with "Calvin"
let middleIndex = Math.floor(styles.length / 2);
styles[middleIndex] = "Calvin";
console.log(styles);

// Remove the first value of the array and show it
let firstValue = styles.shift();
console.log(firstValue);
console.log(styles);

// Prepend "Rose" and "Regal" to the array
styles.unshift("Rose", "Regal");
console.log(styles);