// Solution 1

const regex1 = /q|w|e|r|t|y|u|ı|o|p|ğ|ü/gi;
const regex2 = /a|s|d|f|g|h|j|k|l|ş|i/gi;
const regex3 = /z|x|c|v|b|n|m|ö|ç/gi;

const givenArray = ["asli", "menekşe", "çöz", "giresun"];

let resultArray = [];

for (let i = 0; i < givenArray.length; i++) {
  let result1 = givenArray[i].match(regex1);
  let result2 = givenArray[i].match(regex2);
  let result3 = givenArray[i].match(regex3);

  const resultItem = [result1, result2, result3];

  const resultLast = resultItem.find((item) => {
    let a = item ? item.join("") : "";
    return a === givenArray[i];
  });

  if (resultLast) {
    resultArray.push(resultLast.join(""));
  }
}

console.log(resultArray);

// Solution 2

/* const letters = ["qwertyuiopğü", "asdfghjklşi", "zxcvbnmöç"] 
const givenArray = ["asli", "menekşe", "çöz", "giresun"];

const isIncludedWord = (word) => {

    if (word.split("").every(item => letters[0].includes(item))) {
        console.log(`${word} birinci satırdaki harflerden oluşuyor`)
        return true;
    }

    else if (word.split("").every(item => letters[1].includes(item))) {
        console.log(`${word} ikinci satırdaki harflerden oluşuyor`)
        return true;
    }

    else if (word.split("").every(item => letters[2].includes(item))) {
        console.log(`${word} üçüncü satırdaki harflerden oluşuyor`)
        return true;
    }

    return false;

}


const filteredArray = (arr) => {
    const foundWords = arr.filter(item => isIncludedWord(item));
    console.log(foundWords)
}

filteredArray(givenArray); */

// verilen array : [asli, menekşe, çöz, giresun]
// cikti [asli, çöz]
// asli ikinci satırdaki harflerden oluşuyor
// çöz üçüncü satırdaki harflerden oluşuyor
