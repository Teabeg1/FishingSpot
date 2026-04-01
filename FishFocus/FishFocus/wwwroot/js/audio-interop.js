window.audioInterop = {

    play: function (id) {
        var audio = document.getElementById(id);
        if (audio) {
            audio.play().catch(function (error) {
                console.error("Playback error:", error);
            });
        }
    },

    pause: function (id) {
        var audio = document.getElementById(id);
        if (audio) {
            audio.pause();
        }
    },

    setVolume: function (id, volume) {
        var audio = document.getElementById(id);
        if (audio) {
            audio.volume = volume / 100;
        }
    },

    setCurrentTime: function (id, time) {
        var audio = document.getElementById(id);
        if (audio) {
            if (audio.duration && time > audio.duration) {
                audio.currentTime = 0;
            } else {
                audio.currentTime = time;
            }
        }
    },

    focusElement: function (id) {
        const el = document.getElementById(id);
        if (el) {
            el.focus();
            el.select();
        }
    }
};

window.playTickSound = function () {
    const audio = new Audio('/audio/sound-time.mp3');
    audio.currentTime = 0;
    audio.play().catch(e => console.log(e));
};

window.playOneShot = function (src) {
    const audio = new Audio(src);
    audio.currentTime = 0;
    audio.play().catch(e => console.log(e));
};