var requestURL = 'https://mdn.github.io/learning-area/javascript/oojs/json/superheroes.json';
var request = new XMLHttpRequest();
request.open('GET', requestURL);
request.responseType = 'text';
request.send();


request.onload = function () {
    var superHeroesText = request.response;
    var superHeroes = JSON.parse(superHeroesText);
    populateHeader(superHeroes);
    showHeroes(superHeroes);
}

//Populate header
function populateHeader(jsonObj) {
    //create header1
    var myH1 = document.createElement('h1');
    //Set header text
    myH1.textContent = jsonObj['squadName'];
    //append h1 to header
    header.appendChild(myH1);
    //create paragraph
    var myPara = document.createElement('p');
    //set paragraph text
    myPara.textContent = 'Hometown: ' + jsonObj['homeTown'] + ' // Formed: ' + jsonObj['formed'];
    //append paragraph to the header
    header.appendChild(myPara);
}

function showHeroes(jsonObj) {
    //put all the members into a variable
    var heroes = jsonObj['members'];
    //runs through the heroes array and creates articles for each
    for (var i = 0; i < heroes.length; i++) {
        //creates elements for each hero
        var myArticle = document.createElement('article');
        var myH2 = document.createElement('h2');
        var myPara1 = document.createElement('p');
        var myPara2 = document.createElement('p');
        var myPara3 = document.createElement('p');
        var myList = document.createElement('ul');
        //Apply text data to each element
        myH2.textContent = heroes[i].name;
        myPara1.textContent = 'Secret identity: ' + heroes[i].secretIdentity;
        myPara2.textContent = 'Age: ' + heroes[i].age;
        myPara3.textContent = 'Superpowers:';
        //Runs through the hero powers array and applies to list
        var superPowers = heroes[i].powers;
        for (var j = 0; j < superPowers.length; j++) {
            var listItem = document.createElement('li');
            listItem.textContent = superPowers[j];
            //append each list item to myList
            myList.appendChild(listItem);
        }
        //appends all elements to article
        myArticle.appendChild(myH2);
        myArticle.appendChild(myPara1);
        myArticle.appendChild(myPara2);
        myArticle.appendChild(myPara3);
        myArticle.appendChild(myList);
        //append article to section
        section.appendChild(myArticle);
    }
}
