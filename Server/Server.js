const dotenv = require('dotenv');
dotenv.config();

const express = require('express');
const app = express();
const port = process.env.PORT || 3000;
const bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({ extended: true }));

const mysql      = require('mysql');
const connection = mysql.createConnection({
  host     : process.env.DB_HOST,
  user     : process.env.DB_USERNAME,
  password : process.env.DB_PASSWORD,
  database : 'top_shooting'
});
connection.connect();
app.get('/', (req, res) => {
    res.json({
        success: true,
    });
});

app.get('/hello', (req, res) => {
    res.json({
        msg: "hello world",
    });
});

app.get('/ranking', (req, res) => {
    const rankings = [];
    
    connection.query(`SELECT * FROM top_shooting.userscores;`, (error, results, field)=>{
        if(error)
        {
             console.log(error);
        }
        console.log(results);

        results.sort((a, b) => b.score - a.score);

        res.json(results);
    }) ;
});

app.post('/registerScore', (req, res, next) => {
    var name = req.body.name;
    var score = req.body.score;

    connection.query(`INSERT INTO top_shooting.userscores VALUES('${name}', ${score}) ON DUPLICATE KEY UPDATE score = ${score};`, (error, results, field)=>{
        if(error)
        {
             console.log(error);
        }
        console.log(results);
    }) ;
  
    console.log('name: ' + name + ' score: '+ score);

    res.json({ success: true });
});

app.listen(port, () => {
    console.log(`server is listening at localhost:${port}`);
});

console.log("노드몬 ㄹㅇㅋㅋ");