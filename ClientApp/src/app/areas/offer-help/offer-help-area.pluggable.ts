export const offerHelpAreaPluggable = {
  lazyRoutes: [
    {
      path: 'offer-help',
      loadChildren: () => import('./offer-help-area.module').then((m) => m.OfferHelpAreaModule),
    },
  ],
};
