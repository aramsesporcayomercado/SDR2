document.addEventListener('DOMContentLoaded', function () {
    const openModalBtn = document.getElementById('openModalBtn');
    const modal = document.getElementById('modal');
    const closeModalBtn = document.querySelector('.close');
    const form = document.getElementById('form');
    const downloadFormExcelBtn = document.getElementById('downloadFormExcel');
    const downloadFormPDFBtn = document.getElementById('downloadFormPDF');
  
    openModalBtn.addEventListener('click', function () {
      modal.style.display = 'block';
    });
  
    closeModalBtn.addEventListener('click', function () {
      modal.style.display = 'none';
    });
  
    window.addEventListener('click', function (event) {
      if (event.target === modal) {
        modal.style.display = 'none';
      }
    });
  
    form.addEventListener('submit', function (event) {
      event.preventDefault();
  
      const name = document.getElementById('name').value;
      const email = document.getElementById('email').value;
  
      generatePDF(name, email);
    });
  
    downloadFormExcelBtn.addEventListener('click', function () {
      fetch('/upload-excel')
        .then(response => response.blob())
        .then(blob => {
          const url = URL.createObjectURL(blob);
          const a = document.createElement('a');
          a.href = url;
          a.download = 'data.xlsx';
          a.click();
        });
    });
  
    downloadFormPDFBtn.addEventListener('click', function () {
      const formData = new FormData(form);
      const data = Array.from(formData.entries());
      const content = data.map(([key, value]) => `${key}: ${value}`).join('\n');
      
      generatePDF(content);
    });
  
    function generatePDF(name, email) {
      const content = `Nombre: ${name}\nCorreo electrónico: ${email}`;
      const formData = new FormData();
      formData.append('name', name);
      formData.append('email', email);
  
      fetch('/generate-pdf', {
        method: 'POST',
        body: formData,
      })
        .then(response => response.blob())
        .then(blob => {
          const url = URL.createObjectURL(blob);
          const a = document.createElement('a');
          a.href = url;
          a.download = 'formulario.pdf';
          a.click();
        });
    }
  
    document.getElementById('excelFile').addEventListener('change', function (event) {
      const file = event.target.files[0];
      const formData = new FormData();
      formData.append('excelFile', file);
      
      fetch('/upload-excel', {
        method: 'POST',
        body: formData,
      })
        .then(response => response.blob())
        .then(blob => {
          const url = URL.createObjectURL(blob);
          const a = document.createElement('a');
          a.href = url;
          a.download = 'data.xlsx';
          a.click();
        });
    });
  });
  