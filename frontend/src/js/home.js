document.addEventListener('DOMContentLoaded', function() {
    var filterButton = document.getElementById('filter_button');
    var menuListFilter = document.getElementById('menu_list_filter');
    var svgElement = filterButton.querySelector('.rotate-svg');

    filterButton.addEventListener('click', function() {
        if (menuListFilter.style.display === "none") {
            menuListFilter.style.display = "block";
            svgElement.classList.add('rotated');
        } else {
            menuListFilter.classList.add('menu-list-filter-to');
            setTimeout(function() {
                menuListFilter.style.display = "none";
                menuListFilter.classList.remove('menu-list-filter-to');
            }, 500);
            svgElement.classList.remove('rotated');
        }
    });
});