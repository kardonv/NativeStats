class NSCarouselComponent extends HTMLElement {
    constructor() {
        super();
        this.attachShadow({ mode: 'open' });

        this.isDragging = false;
        this.startX = 0;
        this.currentTranslate = 0;
        this.previousTranslate = 0;
    }

    connectedCallback() {
        const template = document.getElementById('carousel-template');
        this.shadowRoot.appendChild(template.content.cloneNode(true));

        this.carousel = this.shadowRoot.getElementById('carousel');
        this.addEventListeners();
    }

    addEventListeners() {
        this.carousel.addEventListener('mousedown', this.startDrag.bind(this));
        this.carousel.addEventListener('mousemove', this.drag.bind(this));
        this.carousel.addEventListener('mouseup', this.endDrag.bind(this));
        this.carousel.addEventListener('mouseleave', this.endDrag.bind(this));
        this.carousel.addEventListener('touchstart', this.startDrag.bind(this), { passive: true });
        this.carousel.addEventListener('touchmove', this.drag.bind(this), { passive: true });
        this.carousel.addEventListener('touchend', this.endDrag.bind(this));
    }

    startDrag(event) {
        this.isDragging = true;
        this.startX = this.getEventPosition(event);
        this.carousel.style.transition = 'none';
    }

    drag(event) {
        if (!this.isDragging) return;
        const currentX = this.getEventPosition(event);
        const distance = currentX - this.startX;
        this.currentTranslate = this.previousTranslate + distance > 200 ? 0 : this.previousTranslate + distance;
        this.setCarouselPosition();
    }

    endDrag() {
        if (!this.isDragging) return;
        this.isDragging = false;
        this.previousTranslate = this.currentTranslate;
        this.carousel.style.transition = 'transform 0.3s ease-out';
    }

    getEventPosition(event) {
        return event.type.includes('mouse') ? event.pageX : event.touches[0].clientX;
    }

    setCarouselPosition() {
        this.carousel.style.transform = `translateX(${this.currentTranslate}px)`;
    }
}

customElements.define("ns-carousel", NSCarouselComponent);