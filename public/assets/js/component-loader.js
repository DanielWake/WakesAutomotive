/**
 * Component Loader - MVC-style component injection for flat file websites
 * Loads HTML components and injects them into designated elements
 */

class ComponentLoader {
    constructor() {
        this.componentsPath = '/public/views/components/';
        this.loadedComponents = new Map();
    }

    async loadComponent(componentName) {
        if (this.loadedComponents.has(componentName)) {
            return this.loadedComponents.get(componentName);
        }

        try {
            const response = await fetch(`${this.componentsPath}${componentName}.html`);
            if (!response.ok) {
                throw new Error(`Failed to load component: ${componentName}`);
            }
            const html = await response.text();
            this.loadedComponents.set(componentName, html);
            return html;
        } catch (error) {
            console.error(`Error loading component ${componentName}:`, error);
            return '';
        }
    }

    async injectComponent(elementSelector, componentName, data = {}) {
        const element = document.querySelector(elementSelector);
        if (!element) {
            console.error(`Element not found: ${elementSelector}`);
            return;
        }

        let html = await this.loadComponent(componentName);

        // Simple template variable replacement
        Object.keys(data).forEach(key => {
            const regex = new RegExp(`{{${key}}}`, 'g');
            html = html.replace(regex, data[key]);
        });

        element.innerHTML = html;
    }

    async loadAllComponents() {
        const components = document.querySelectorAll('[data-component]');
        const loadPromises = Array.from(components).map(async (element) => {
            const componentName = element.getAttribute('data-component');
            const dataAttr = element.getAttribute('data-props');
            const data = dataAttr ? JSON.parse(dataAttr) : {};

            let html = await this.loadComponent(componentName);

            // Simple template variable replacement
            Object.keys(data).forEach(key => {
                const regex = new RegExp(`{{${key}}}`, 'g');
                html = html.replace(regex, data[key]);
            });

            element.innerHTML = html;
        });

        await Promise.all(loadPromises);
        this.initializeEventListeners();
    }

    initializeEventListeners() {
        // Initialize mobile menu toggle
        const menuToggle = document.querySelector('.mobile-menu-toggle');
        const navMenu = document.querySelector('.nav-menu');

        if (menuToggle && navMenu) {
            menuToggle.addEventListener('click', () => {
                navMenu.classList.toggle('active');
                menuToggle.classList.toggle('active');
            });
        }

        // Highlight active navigation item
        const currentPath = window.location.pathname;
        const navLinks = document.querySelectorAll('.nav-menu a');
        navLinks.forEach(link => {
            const href = link.getAttribute('href');
            if (href && (currentPath === href || currentPath.includes(href.replace('.html', '')))) {
                link.classList.add('active');
            }
        });
    }
}

// Initialize component loader when DOM is ready
document.addEventListener('DOMContentLoaded', async () => {
    const loader = new ComponentLoader();
    await loader.loadAllComponents();
});
