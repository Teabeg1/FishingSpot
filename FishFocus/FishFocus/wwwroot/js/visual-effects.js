window.visualEffects = {
    createRipple: function (selector, clientX, clientY) {
        const container = document.querySelector(selector);
        if (!container) return;

        const rect = container.getBoundingClientRect();

        const x = clientX - rect.left;
        const y = clientY - rect.top;

        const ripple = document.createElement("div");
        ripple.className = "click-ripple";

        ripple.style.left = `${x}px`;
        ripple.style.top = `${y}px`;

        container.appendChild(ripple);

        setTimeout(() => {
            ripple.remove();
        }, 1000);
    }
};