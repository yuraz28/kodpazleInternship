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

// Создаем массив для хранения ссылок на input элементы
var inputs = [];

// Создаем переменную для отслеживания текущего номера списка
var listCounter = 1;

var buttons = document.querySelectorAll('#categoryButtons button');
buttons.forEach(function(button) {
    button.addEventListener('click', function() {
        var articleText = document.querySelector('.article_text');
        var newInput = document.createElement('input');
        newInput.type = 'text';
        newInput.id = 'input' + this.id;
        newInput.placeholder = this.textContent;
        newInput.style.outline  = 'none';
        newInput.style.fontSize  = '20px';

        // Вставляем новый input в конец блока article_text
        articleText.appendChild(newInput);
        inputs.push(newInput); // Добавляем ссылку на новый input в массив
        newInput.focus();
        
        // Ставим фокус на новом input'е
        var categoryButtons = document.getElementById('categoryButtons');
        categoryButtons.style.display = 'none';
        categoryButtons.classList.remove('fadeIn'); 
        
        newInput.addEventListener('keydown', function(event) {
            if (event.key === 'Enter') {
                event.preventDefault();
                var textContent = newInput.value.trim();
                if (textContent === '') {
                    // Если строка пустая, не создаем элемент и завершаем функцию
                    newInput.parentNode.removeChild(newInput);
                    return;
                } else {    
                    var newElement;
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
                            listCounter = 1; // Сбрасываем счетчик только если это первый элемент списка
                        }
                        newElement = document.createElement('li');
                        newElement.textContent = textContent;
                        newElement.style.fontSize = '18px';
                        ol.appendChild(newElement);
                        listCounter++; // Увеличиваем счетчик списка
                    } else if (newInput.id === 'inputvideo') {
                        newElement = document.createElement('iframe');
                        newElement.src = textContent;
                        newElement.width = '800';
                        newElement.height = '400';
                        articleText.appendChild(newElement);
                    } else if (newInput.id === 'inputphoto') {
                        newElement = document.createElement('p');
                        newElement.textContent = textContent;
                        newElement.style.fontSize = '18px'
                        newElement.style.textAlign = 'center'
                        articleText.appendChild(newElement);
                        newInput.parentNode.removeChild(newInput);
                    }else {
                        newElement = document.createElement('p');
                        newElement.textContent = textContent;
                    }if (newInput.id !== 'inputli' && newInput.id !== 'inputnumli' && newInput.id !== 'inputvideo' && newInput.id !== 'inputphoto') {
                        newElement.textContent = textContent;
                        articleText.appendChild(newElement);
                    }
                }
                // Удаляем input после создания элемента
                newInput.parentNode.removeChild(newInput);
            }
        });
    });
});

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

// Обновляем логику добавления нового абзаца при нажатии Enter
document.getElementById('article_text').addEventListener('keydown', function(event) {
    if (event.key === 'Enter') {
        event.preventDefault();
        var articleText = document.querySelector('.article_text');
        var textContent = articleText.querySelector('input').value;
        if (textContent.trim() === '') {
            var newLine = document.createElement('br');
            articleText.appendChild(newLine);
        } else {    
            var newParagraph = document.createElement('p');
            newParagraph.textContent = textContent;
            newParagraph.style.fontSize = "20px"
            articleText.appendChild(newParagraph);
        }
        // Очищаем содержимое текущего input'а
        articleText.querySelector('input').value = '';
        // Очищаем содержимое всех остальных input'ов
        inputs.forEach(function(input) {
            if (input!== articleText.querySelector('input')) {
                input.value = '';
            }
        });
    }
});
