var lineNumber = 1;

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

// Обработчики событий для кнопок в 'categoryButtons'
var buttons = document.querySelectorAll('#categoryButtons button');
buttons.forEach(function(button) {
    button.addEventListener('click', function() {
        var articleText = document.querySelector('.text-post-std');
        
        var newInput = document.createElement('input');
        newInput.type = 'text';
        newInput.id = 'input' + this.id;
        newInput.placeholder = this.textContent;
        newInput.style.outline = 'none';
        newInput.style.fontSize = '20px';

        articleText.appendChild(newInput);
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
                        if (newInput.id === 'inputh1') {
                            newElement = document.createElement('h1');
                            newElement.style.fontSize = '20px';
                            newElement.style.marginTop = '10px';
                            newElement.style.fontWeight = '700';
                        } else if (newInput.id === 'inputli') {
                            newElement = document.createElement('li');
                            newElement.textContent = textContent;
                            newElement.style.fontSize = '18px';
                            var ul = document.querySelector('.article_text ul');
                            if (!ul) {
                                ul = document.createElement('ul');
                                ul.style.fontSize = '18px';
                                ul.style.marginTop = '10px';
                                ul.style.marginBottom = '10px';
                                articleText.appendChild(ul);
                            }
                            ul.appendChild(newElement);
                        } else if (newInput.id === 'inputnumli') {
                            var ol = document.querySelector('.article_text ol');
                            if (!ol) {
                                ol = document.createElement('ol');
                                articleText.appendChild(ol);
                            }
                            newElement = document.createElement('li');
                            newElement.textContent = textContent;
                            newElement.style.fontSize = '18px'; 
                            ol.appendChild(newElement);
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
                    if (newInput.id !== 'inputli' && newInput.id !== 'inputnumli' && newInput.id !== 'inputvideo' && newInput.id !== 'inputphoto') {
                        newElement.textContent = textContent;
                        articleText.appendChild(newElement);
                    }
                }
                newInput.parentNode.removeChild(newInput);
            }
        });
    });
});

// Обработчик для кнопки 'photo'
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
                document.querySelector('.text-post-std').appendChild(imgElement);
            };
            reader.readAsDataURL(file);
        }
    });
    fileInput.click();
});

// Обработчик для кнопки 'button-back'
document.addEventListener('DOMContentLoaded', function() {
    var backButton = document.getElementById('button-back');
    backButton.addEventListener('click', function() {
        window.location.href = 'Manager.html';
    });
});

// Обработчик для 'article_text'
document.getElementById('article_text').addEventListener('keydown', function(event) {
    if (event.key === 'Enter') {
        event.preventDefault();
        var textContent = this.value;
        if (textContent !== '') {
            var newParagraph = document.createElement('p');
            newParagraph.style.fontSize = '20px';
            newParagraph.textContent = textContent;

            var textPostStdElement = document.querySelector('.text-post-std');
            textPostStdElement.appendChild(newParagraph);

            this.value = '';
        }
    }
});

function getTextPostStdContent() {
    var textPostStdElement = document.querySelector('.text-post-std');
    var content = '';
    for (var i = 0; i < textPostStdElement.childNodes.length; i++) {
        content += textPostStdElement.childNodes[i].outerHTML;
    }
    return content;
}

async function sendContentAsText() {
    try {
        var encodedContent = encodeURIComponent(getTextPostStdContent());
        const response = await axios.post(`http://192.168.251.33:5050/api/updateposttext?newText=${encodedContent}`, '', {
            headers: {
                'Content-Type': 'text/plain;charset=utf-8'
            }
        });

        console.log('Ответ от сервера:', response.data);
    } catch (error) {
        console.error('Ошибка при отправке данных:', error);
    }
}

document.getElementById('next_article').addEventListener('click', sendContentAsText);