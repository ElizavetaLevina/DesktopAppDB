﻿using WinFormsApp1.DTO;
using WinFormsApp1.Logic.Interfaces;
using WinFormsApp1.Repository.Interfaces;

namespace WinFormsApp1.Logic
{
    public class MastersLogic : IMastersLogic
    {
        IMasterRepository _masterRepository;
        public MastersLogic(IMasterRepository masterRepository)
        {
            _masterRepository = masterRepository;
        }

        /// <inheritdoc/>
        public List<MasterDTO> GetMastersForOutput()
        {
            return _masterRepository.GetMastersForOutput();
        }

        /// <inheritdoc/>
        public List<MasterEditDTO> GetMasters()
        {
            return _masterRepository.GetMasters();
        }

        /// <inheritdoc/>
        public MasterEditDTO GetMaster(int? id)
        {
            var masterDTO = _masterRepository.GetMaster(id);
            if (masterDTO == null)
                return new MasterEditDTO();
            else 
                return masterDTO;
        }

        /// <inheritdoc/>
        public async Task SaveMasterAsync(MasterEditDTO masterDTO)
        {
            await _masterRepository.SaveMasterAsync(masterDTO);
        }

        /// <inheritdoc/>
        public async Task RemoveMasterAsync(MasterEditDTO masterDTO)
        {
            await _masterRepository.RemoveMasterAsync(masterDTO);
        }

    }
}