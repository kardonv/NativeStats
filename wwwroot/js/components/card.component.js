class NSCardComponent extends HTMLElement {
    constructor() {
        super();

        const shadow = this.attachShadow({ mode: "open" });
    }

    connectedCallback() {
        const element = document.getElementById("ns-card-template");

        if (!element) return;

        const template = element.content.cloneNode(true)
        
        
       
        template.querySelector(".home-team-logo").src = this.getAttribute("home-team-logo") || "";
        template.querySelector(".away-team-logo").src = this.getAttribute("away-team-logo") || "";

        this.shadowRoot.appendChild(template);
    }
}

customElements.define("ns-card", NSCardComponent);