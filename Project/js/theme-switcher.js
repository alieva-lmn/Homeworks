document.addEventListener('DOMContentLoaded', function () { 
    const btnThemeToggleOff = document.querySelector('.btnTheme-toggle-off');
    const themeStyle = document.getElementById('theme-style');
    const savedTheme = localStorage.getItem('theme');

    if (savedTheme) {
        themeStyle.setAttribute('href', savedTheme);
    }

    btnThemeToggleOff.addEventListener('click', function () {

        const iconElement = btnThemeToggleOff.querySelector('a');

        if (themeStyle.getAttribute('href') === 'css/light-theme.css') {
            themeStyle.setAttribute('href', 'css/dark-theme.css');
            localStorage.setItem('theme', 'css/dark-theme.css');

            iconElement.classList.remove('fa-toggle-off');
            iconElement.classList.add('fa-toggle-on');
        } else {
            themeStyle.setAttribute('href', 'css/light-theme.css');
            localStorage.setItem('theme', 'css/light-theme.css');

            iconElement.classList.remove('fa-toggle-on');
            iconElement.classList.add('fa-toggle-off');
        }
    });
});