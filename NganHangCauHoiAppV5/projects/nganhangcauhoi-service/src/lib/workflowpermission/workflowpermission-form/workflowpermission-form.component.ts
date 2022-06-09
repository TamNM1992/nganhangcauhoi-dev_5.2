

import { Component, Injector, Input, OnInit } from '@angular/core';
import {
    ComponentContextService, DataFormBase, EventData, FormSchemaBase, TextControlSchema,
    SwitchControlSchema, DateTimeControlSchema, LabelSchema, EditorControlSchema
} from 'tnx-shared';
import { WorkflowPermissionService } from 'tnx-nganhangcauhoi-service/workflowpermission/services';

@Component({
    selector: 'workflowpermission-form',
    templateUrl: './workflowpermission-form.component.html',
    styleUrls: ['./workflowpermission-form.component.scss'],
    providers: [ComponentContextService],
})
export class WorkflowPermissionFormComponent extends DataFormBase implements OnInit {

    constructor(
        protected _injector: Injector,
        private _workflowPermissionService: WorkflowPermissionService
    ) {
        super(_injector);
    }

    ngOnInit() {
        super.ngOnInit();
        this.setting.baseService = this._workflowPermissionService;
        this.setting.schema = <FormSchemaBase[]>[
        new SwitchControlSchema ({
				label: '',
				fullLabel: '' 
				field: 'allowEdit',
				defaultValue: true
			}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'code'}),
			new SwitchControlSchema ({
				label: '',
				fullLabel: '' 
				field: 'completed',
				defaultValue: true
			}),
			new DateTimeControlSchema ({
				label: '',
				fullLabel: '' 
				field: 'created'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'createdBy'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'currentStateCode'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'donViIdLastInWorkflow'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'donViIds'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'entity'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'entityKey'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'groupIds'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'hemisCode'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'hemisId'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'id'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'idHistory'}),
			new SwitchControlSchema ({
				label: '',
				fullLabel: '' 
				field: 'isBuildIn',
				defaultValue: true
			}),
			new SwitchControlSchema ({
				label: '',
				fullLabel: '' 
				field: 'isBuildInAll',
				defaultValue: true
			}),
			new SwitchControlSchema ({
				label: '',
				fullLabel: '' 
				field: 'isDeleted',
				defaultValue: true
			}),
			new SwitchControlSchema ({
				label: '',
				fullLabel: '' 
				field: 'isPrivate',
				defaultValue: true
			}),
			new SwitchControlSchema ({
				label: '',
				fullLabel: '' 
				field: 'isPublic',
				defaultValue: true
			}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'itemId'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'link'}),
			new DateTimeControlSchema ({
				label: '',
				fullLabel: '' 
				field: 'modified'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'modifiedBy'}),
			new SwitchControlSchema ({
				label: '',
				fullLabel: '' 
				field: 'notInWorkflow',
				defaultValue: true
			}),
			new TextControlSchema({
				label: 'Như permission nhị phân của phần phân quyền',
				fullLabel: 'Như permission nhị phân của phần phân quyền' 
				field: 'permission',
				dataFormat: 'number',
			}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'persistedId',
				dataFormat: 'number',
			}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'printFileId'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'roleIds'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'serviceCode'}),
			new SwitchControlSchema ({
				label: '',
				fullLabel: '' 
				field: 'synced',
				defaultValue: true
			}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'tableName'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'textTrangThai'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'trangThai'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'type',
				dataFormat: 'number',
			}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'userIdCreated'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'userIdLastInWorkflow'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'userIds'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'userIdsCombine'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'version',
				dataFormat: 'number',
			}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'workflowCode'}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'workflowCoreStatus',
				dataFormat: 'number',
			}),
			new TextControlSchema({
				label: '',
				fullLabel: '' 
				field: 'workflowStateType',
				dataFormat: 'number',
			}),
			
        ];
    }

    async onFormInitialized(formEvent: EventData) {
        // tiền xử lý dữ liệu (ví dụ tổng hợp datasource), trước khi gọi api get detail

    }

    async modifyDetailData(data) {
        // xử lý dữ liệu lấy từ get detail về
    }

    onBeforeSave() {
        // trước khi lưu
    }
}
