const path = require('path')
const fs = require('fs')
const convert = require('xml-js')
const jsonServer = require('json-server')
const filedb = path.join(__dirname, 'db.json')
const server = jsonServer.create()
const router = jsonServer.router(filedb)
const middlewares = jsonServer.defaults()
 
server.use(middlewares)

server.use(jsonServer.bodyParser)

server.get('/api', (req, res) => {
    // fs.readFile(filedb, 'utf8', (err, data) => {
    //     if (err) throw err;
    //     res.send(JSON.parse(data));
    // });

    var rawdata = fs.readFileSync(filedb, 'utf8');
    var content_json = JSON.parse(rawdata);
    var content = '', content_type = '';

    if(req.query.format === 'xml') {
      content = '<?xml version="1.0" encoding="UTF-8"?>\r\n<mydata>\r\n' + convert.json2xml(content_json, {compact: true, ignoreComment: true, spaces: 4}) + '\r\n</mydata>';
      content_type = "application/xml";
    } else {
      content = content_json;
      content_type = "application/json";
    }

    res.setHeader("Content-Type", content_type);
    res.send(content);
})

server.use((req, res, next) => {
    if (req.method === 'POST') {
      req.body.createdAt = Date.now()
    }
    router.db.assign(require('require-uncached')(filedb)).write();
    next()
})

server.use(jsonServer.rewriter({
    '/api/*': '/$1'
}))

server.use(router)
server.listen(3000, () => {
  console.log('JSON Server is running')
})