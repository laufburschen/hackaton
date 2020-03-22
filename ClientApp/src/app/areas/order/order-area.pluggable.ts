export const orderAreaPluggable = {
  lazyRoutes: [
    {
      path: 'order',
      loadChildren: () => import('./order-area.module').then((m) => m.OrderAreaModule),
    },
  ],
};
