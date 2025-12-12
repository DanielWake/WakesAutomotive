// Wakes Autocare - Main JavaScript

document.addEventListener('DOMContentLoaded', function() {
    console.log('Wakes Autocare website loaded');

    // Add smooth scrolling for anchor links (but not for dropdown triggers)
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            const href = this.getAttribute('href');

            // Skip if href is just '#' (dropdown triggers, etc.)
            if (href === '#' || href.length <= 1) {
                return;
            }

            e.preventDefault();
            const target = document.querySelector(href);
            if (target) {
                target.scrollIntoView({
                    behavior: 'smooth'
                });
            }
        });
    });
});
