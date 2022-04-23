import { Splide } from "@splidejs/splide";
import { AutoScroll } from "@splidejs/splide-extension-auto-scroll";

const AutoScrollComponent=
  new Splide(".spices-auto-scroll", {
    padding: 10,
    type: "loop",
    drag: "free",
    focus: "center",
    speed: 500,
    width: "100%",
    perPage: 5,
    breakpoints: {
      375: {
        perPage: 1,
      },
      576: {
        perPage: 2,
      },
      991: {
        perPage: 3,
      },
      992: {
        perPage: 4,
      },
      1024: {
        perPage: 4,
      },
      1200: {
        perPage: 5,
      },
    },
    autoScroll: {
      speed: 1,
    },
  }).mount({ AutoScroll });

// document.addEventListener( 'DOMContentLoaded', function() {
//     new Splide( '.spices-auto-scroll', {
//         padding: 10,
//         type: 'loop',
//         speed: 1000,
//         perPage:5,
//         width:'100%',
//         breakpoints: {
//           375: {
//               perPage: 1,
//           },
//           576: {
//               perPage: 2,
//           },
//           991: {
//               perPage: 3,
//           },
//           992: {
//               perPage: 4,
//           },
//           1024: {
//               perPage: 4,
//           },
//           1200: {
//               perPage: 5,
//           }
//     },
//         autoScroll: {
//         speed: 1,
//       },
//     }).mount( window.splide.Extensions );
//   } );

export default AutoScrollComponent;
