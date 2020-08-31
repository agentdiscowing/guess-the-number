import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { GameplayComponent } from './gameplay/gameplay.component';

const appRoutes: Routes = [
    { path: 'play', component: GameplayComponent }
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class GameRoutingModule {}
