const {kopekTemizle, kopekBakım }= require('./kopekBakımUtility');
const {kopek} = require('./kopek');

console.log(`Köpek adı : ${kopek.name} \n Köpek boyu : ${kopek.height} \n Köpek kilosu : ${kopek.kg} \n Köpek cinsi : ${kopek.kind} \n Köpek yaşı : ${kopek.age}`);

kopekTemizle();

console.log(`Köpek ilgi saati : ${kopekBakım}`)


/*// kopek adi : "Corap"
 // kopek boyu : 51 cm
 // kopeginiz yikandı
 // kopek ilgi saati : 30 */