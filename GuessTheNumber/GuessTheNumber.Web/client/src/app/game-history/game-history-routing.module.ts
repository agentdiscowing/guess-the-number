import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HistoryTableComponent } from './history-table/history-table.component';

const appRoutes: Routes = [
    { path: 'history', component: HistoryTableComponent }
];

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [
        RouterModule
    ]
})
export class GameHistoryRoutingModule {}
