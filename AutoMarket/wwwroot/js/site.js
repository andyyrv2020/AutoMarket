(() => {
    const root = document.documentElement;
    const toggle = document.getElementById('themeToggle');
    const label = document.getElementById('themeLabel');
    const saved = localStorage.getItem('theme') || 'dark';
    root.setAttribute('data-theme', saved);
    updateToggle(saved);

    toggle?.addEventListener('click', () => {
        const current = root.getAttribute('data-theme') === 'light' ? 'dark' : 'light';
        root.setAttribute('data-theme', current);
        localStorage.setItem('theme', current);
        updateToggle(current);
    });

    function updateToggle(mode) {
        if (!label) return;
        label.textContent = mode === 'light' ? 'Switch Theme' : 'Switch Theme';
        const icon = document.querySelector('.theme-icon');
        if (icon) icon.textContent = mode === 'light' ? '☀️' : '🌙';
    }
})();
