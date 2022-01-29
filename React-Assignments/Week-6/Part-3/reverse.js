let myString = "Burada reverse işlemi olacak!";


// Solution 1 :

const reverseString1 = myString.split("").reverse().join("");
//console.log(reverseString1)


// Solution 2 :

const reverseString2 = [...myString].reverse().join("");
//console.log(reverseString2);



// Solution 3 :

const reverseString3 = (str) => {
    let reverseString = "";

    for (let i = str.length - 1; i >= 0; i--) {
        reverseString += str[i];
    }

    return reverseString;
}

//console.log(reverseString3(myString));



// Solution 4 ;

const reverseString4 = (str) => {
    
    const reverseString = [...str].reduceRight((acc, item) => acc.concat(item));
    return reverseString;
}

//console.log(reverseString4(myString));


// AÇIKLAMA 

// Burada hem bir ES6 özelliği olan Spread Operatörünün kullanılması hem de bu durumun daha temiz bir kod yazımı sağlaması (Clean Code prensibi) sebebiyle en mantıklı çözüm Solution 2 olacaktır. Ancak, bu ödev sayesinde öğrendiğim reduceRight metodu da işlevsel bir kullanıma sahip.