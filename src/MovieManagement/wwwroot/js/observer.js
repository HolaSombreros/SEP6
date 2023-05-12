window.Observer = {
  observer: null,
  Initialize: function (component, observableTargetId) {
    this.observer = new IntersectionObserver(e => {
      if (e[0].isIntersecting) {
        component.invokeMethodAsync('OnIntersection');
      }
    });

    let element = document.getElementById(observableTargetId);
    if (element == null) throw new Error("The observable target was not found");
    this.observer.observe(element);
  }
};
