document.addEventListener('DOMContentLoaded', function () {
    const modal = document.getElementById('modal');
    const modalImage = document.getElementById('modal-image');
    const modalTitle = document.getElementById('modal-title');
    const modalDescription = document.getElementById('modal-description');
    const closeBtn = document.getElementsByClassName('close')[0];
    
    const body = document.body;
    var scrollTop;

    if (closeBtn) {
        closeBtn.addEventListener('click', function () {
            body.classList.remove('modal-open');
            modal.style.display = 'none';
            window.scrollTo(0, scrollTop);
        });
    }

    const products = document.querySelectorAll('.box');

    products.forEach(product => {
        const viewDetailsBtn = product.querySelector('.cart-btn');
        const productId = product.getAttribute('data-product-id');
        const productName = product.querySelector('h3').textContent;
        const productImage = product.querySelector('img').getAttribute('src');
        const productDescription = product.querySelector('p').textContent;

        viewDetailsBtn.addEventListener('click', function (event) {

            event.preventDefault();

            scrollTop = window.pageYOffset || document.documentElement.scrollTop;
            body.style.top = `-${scrollTop}px`;
            body.classList.add('modal-open');

            modal.style.display = 'block';

            modalTitle.textContent = productName;
            modalImage.src = productImage;
            modalDescription.textContent = productDescription;

        });
    });


    // window.addEventListener('click', function (event) {
    //     if (event.target === modal) {
    //         body.classList.remove('modal-open');
    //         modal.style.display = 'none';
    //         window.scrollTo(0, scrollTop);
    //     }
    //   });
    
});