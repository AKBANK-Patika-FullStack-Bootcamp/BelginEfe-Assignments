const girlsPowerToplami = (x)=> x + ( x/2) + 3;

const girlsPower = (arr, sum) => arr.map( x => sum(x));

console.log(girlsPower([1,2,3], girlsPowerToplami));