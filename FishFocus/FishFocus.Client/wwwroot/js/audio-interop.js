console.log("Audio-interop.js загружен и готов!");

window.audioInterop = {
    play: function (id) {
        const audio = document.getElementById(id);
        if (audio) audio.play().catch(e => console.log("Play error:", e));
    },
    pause: function (id) {
        const audio = document.getElementById(id);
        if (audio) audio.pause();
    },
    setVolume: function (id, volume) {
        const audio = document.getElementById(id);
        if (audio) audio.volume = volume / 100;
    },

    forceRadioStart: function (id, startTime) {
        const audio = document.getElementById(id);
        if (!audio) return;

        const performJump = () => {
            setTimeout(() => {
                const finalTime = (audio.duration && startTime > audio.duration) ? (audio.duration * 0.1) : startTime;
                audio.currentTime = finalTime;
                console.log("[Radio] Эфир пойман на секунде: " + finalTime);
            }, 150);

            audio.removeEventListener('playing', performJump);
        };

        audio.addEventListener('playing', performJump);
        audio.play().catch(e => console.log("Radio blocked by browser:", e));
    },

    focusElement: function (id) {
        const el = document.getElementById(id);
        if (el) el.focus();
    }
};

window.visualEffects = {
    createRipple: function (selector, clientX, clientY) {
        const container = document.querySelector(selector);
        if (!container) return;

        const rect = container.getBoundingClientRect();
        const ripple = document.createElement("div");
        ripple.className = "click-ripple";

        ripple.style.left = (clientX - rect.left) + "px";
        ripple.style.top = (clientY - rect.top) + "px";

        container.appendChild(ripple);

        setTimeout(() => {
            ripple.style.opacity = "0";
            setTimeout(() => ripple.remove(), 400);
        }, 600);
    }
};

window.playTickSound = function () {
    const audio = new Audio('/audio/sound-time.mp3');
    audio.volume = 0.4;
    audio.play().catch(e => { });
};