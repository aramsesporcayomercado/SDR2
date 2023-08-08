const express = require('express');
const puppeteer = require('puppeteer');
const xlsx = require('xlsx');
const multer = require('multer');
const fs = require('fs');
const path = require('path');
const app = express();
const port = 3000;

app.use(express.static('public'));
app.use(express.urlencoded({ extended: true }));

// Configuración de Multer para la carga de archivos Excel
const storage = multer.diskStorage({
  destination: 'uploads',
  filename: (req, file, cb) => {
    cb(null, file.originalname);
  }
});
const upload = multer({ storage: storage });

app.get('/', (req, res) => {
  res.sendFile(path.join(__dirname, 'public', 'index.html'));
});

app.post('/generate-pdf', async (req, res) => {
  const { name, email } = req.body;
  const content = `Nombre: ${name}\nCorreo electrónico: ${email}`;

  try {
    const pdfBuffer = await generatePDF(content);
    res.setHeader('Content-Disposition', 'attachment; filename=formulario.pdf');
    res.setHeader('Content-Type', 'application/pdf');
    res.send(pdfBuffer);
  } catch (error) {
    console.error('Error al generar el PDF:', error);
    res.status(500).send('Error al generar el PDF');
  }
});

async function generatePDF(content) {
  const browser = await puppeteer.launch();
  const page = await browser.newPage();
  await page.setContent(`<pre>${content}</pre>`);
  const pdfBuffer = await page.pdf({ format: 'A4' });
  await browser.close();
  return pdfBuffer;
}

app.post('/upload-excel', upload.single('excelFile'), (req, res) => {
  const excelFilePath = path.join(__dirname, 'uploads', req.file.filename);

  try {
    const excelData = readExcel(excelFilePath);
    const excelBuffer = generateExcel(excelData);
    
    res.setHeader('Content-Disposition', 'attachment; filename=data.xlsx');
    res.setHeader('Content-Type', 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet');
    res.send(excelBuffer);
  } catch (error) {
    console.error('Error al procesar el archivo Excel:', error);
    res.status(500).send('Error al procesar el archivo Excel');
  }
});

function readExcel(filePath) {
  const workbook = xlsx.readFile(filePath);
  const sheetName = workbook.SheetNames[0];
  const sheet = workbook.Sheets[sheetName];
  return xlsx.utils.sheet_to_json(sheet);
}

function generateExcel(data) {
  const workbook = xlsx.utils.book_new();
  const worksheet = xlsx.utils.json_to_sheet(data);
  xlsx.utils.book_append_sheet(workbook, worksheet, 'Hoja1');
  return xlsx.write(workbook, { type: 'buffer', bookType: 'xlsx' });
}

app.listen(port, () => {
  console.log(`Servidor escuchando en http://localhost:${port}`);
});
