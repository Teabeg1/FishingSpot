window.visualEffects = {
    createRipple: function (containerSelector, x, y) {
        console.log("Клик зафиксирован в:", x, y);
        const container = document.querySelector(containerSelector);
        if (!container) {
            console.error("Контейнер не найден!");
            return;
        }

        const ripple = document.createElement('div');
        ripple.className = 'click-ripple';

        ripple.style.left = x + 'px';
        ripple.style.top = y + 'px';

        container.appendChild(ripple);

        setTimeout(() => {
            ripple.remove();
        }, 1000);
    }
};