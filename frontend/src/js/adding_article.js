document.getElementById('categoryButton').addEventListener('click', function() {
    var categoryButtons = document.getElementById('categoryButtons');
    if (categoryButtons.style.display === 'none') {
        categoryButtons.style.display = 'flex';
        categoryButtons.classList.add('fadeIn');
    } else {
        categoryButtons.style.display = 'none';
        categoryButtons.classList.remove('fadeIn');
    }
});

// Массив для хранения ссылок на input элементы
var inputs = [];

// Переменная для отслеживания текущего номера списка
var listCounter = 1;

// Обработчик для кнопок категорий
var buttons = document.querySelectorAll('#categoryButtons button');
buttons.forEach(function(button) {
    button.addEventListener('click', function() {
        var articleText = document.querySelector('.article_text');
        var newInput = document.createElement('input');
        newInput.type = 'text';
        newInput.id = 'input' + this.id;
        newInput.placeholder = this.textContent;
        newInput.style.outline = 'none';
        newInput.style.fontSize = '20px';

        articleText.appendChild(newInput);
        inputs.push(newInput);
        newInput.focus();

        var categoryButtons = document.getElementById('categoryButtons');
        categoryButtons.style.display = 'none';
        categoryButtons.classList.remove('fadeIn');
        newInput.addEventListener('keydown', function(event) {
            if (event.key === 'Enter') {
                event.preventDefault();
                var textContent = newInput.value.trim();
                if (textContent === '') {
                    newInput.parentNode.removeChild(newInput);
                    return;
                } else {
                    var newElement;
                    if (newInput.tagName.toLowerCase() === 'textarea') {
                        newElement = document.createElement('p');
                        newElement.textContent = textContent;
                    } else {
                        // Логика для других типов input
                        if (newInput.id === 'inputh1') {    
                            newElement = document.createElement('h1');
                            newElement.style.fontSize = '20px';
                            newElement.style.fontWeight = '700';
                        } else if (newInput.id === 'inputli') {
                            newElement = document.createElement('li');
                            newElement.textContent = textContent;
                            newElement.style.fontSize = '18px';
                            var ul = document.querySelector('.article_text ul');
                            if (!ul) {
                                ul = document.createElement('ul');
                                ul.style.fontSize = '18px';
                                articleText.appendChild(ul);
                            }
                            ul.appendChild(newElement);
                        } else if (newInput.id === 'inputnumli') {
                            var ol = document.querySelector('.article_text ol');
                            if (!ol) {
                                ol = document.createElement('ol');
                                articleText.appendChild(ol);
                            }
                            if (articleText.querySelectorAll('ol li').length === 0) {
                                listCounter = 1;
                            }
                            newElement = document.createElement('li');
                            newElement.textContent = textContent;
                            newElement.style.fontSize = '18px';
                            ol.appendChild(newElement);
                            listCounter++;
                        } else if (newInput.id === 'inputvideo') {
                            newElement = document.createElement('iframe');
                            newElement.src = textContent;
                            newElement.width = '800';
                            newElement.height = '400';
                            articleText.appendChild(newElement);
                        } else if (newInput.id === 'inputphoto') {
                            newElement = document.createElement('p');
                            newElement.textContent = textContent;
                            newElement.style.fontSize = '18px';
                            newElement.style.textAlign = 'center';
                            articleText.appendChild(newElement);
                            newInput.parentNode.removeChild(newInput);
                        } else {
                            newElement = document.createElement('p');
                            newElement.textContent = textContent;
                        }
                    }
                    if (newInput.id!== 'inputli' && newInput.id!== 'inputnumli' && newInput.id!== 'inputvideo' && newInput.id!== 'inputphoto') {
                        newElement.textContent = textContent;
                        articleText.appendChild(newElement);
                    }
                }
                newInput.parentNode.removeChild(newInput);
            }
        });
    });
});

// Обработчик для добавления изображений
document.getElementById('photo').addEventListener('click', function() {
    var fileInput = document.createElement('input');
    fileInput.type = 'file';
    fileInput.accept = 'image/*';
    fileInput.style.display = 'none';
    fileInput.addEventListener('change', function(event) {
        var file = event.target.files[0];
        if (file) {
            var reader = new FileReader();
            reader.onload = function(e) {
                var imgElement = document.createElement('img');
                imgElement.src = e.target.result;
                imgElement.width = '800';
                imgElement.height = '400';
                document.querySelector('.article_text').appendChild(imgElement);
            };
            reader.readAsDataURL(file);
        }
    });
    fileInput.click();
});
