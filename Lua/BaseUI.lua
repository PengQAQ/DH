
local UnityEngine=CS.UnityEngine

BaseUI = {}

BaseUI.__index = BaseUI

function BaseUI:new()
	local tempObj = {}
	setmetatable(tempObj, BaseUI)
	return tempObj
end

function BaseUI:OnOpen()
	local canvasGroup = self:GetComponent("CanvasGroup")
	canvasGroup.alpha = 1
	canvasGroup.blockRaycasts = true
	print("open")
end

function BaseUI:OnClose()
	-- body
	local canvasGroup = self:GetComponent("CanvasGroup")
	canvasGroup.alpha = 0;
    canvasGroup.blocksRaycasts = false;
    print("close")
end

function BaseUI:OnResume()
	-- body
	local canvasGroup = self:GetComponent("CanvasGroup")
	canvasGroup.alpha = 0;
    canvasGroup.blocksRaycasts = false;
end

local Main = BaseUI:new()
Main.OnOpen()